using Bogus;
using WARazorDB.Data;
using WARazorDB.Interfaces;
using WARazorDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WARazorDB.Seeders
{
    public class TareaSeeder : IDbInitializer
    {
        public override void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<TareaDbContext>();
            context.Database.EnsureCreated(); 
            SeedTareaData(context);
        }
        private void SeedTareaData(TareaDbContext context)
        {
            context.Tareas.RemoveRange(context.Tareas);
            context.SaveChanges();

            var tareaFaker = new Faker<Tarea>()
                .RuleFor(t => t.nombreTarea, f => f.Lorem.Sentence(3))
                .RuleFor(t => t.fechaVencimiento, f => f.Date.Future(1))
                .RuleFor(t => t.estado, f => f.PickRandom(new[] { "Pendiente", "En Curso", "Finalizado", "Cancelado" }))
                .RuleFor(t => t.idUsuario, f => f.Random.Number(1, 10)); 

            var tareas = tareaFaker.Generate(50);

            context.Tareas.AddRange(tareas);
            context.SaveChanges();
        }
    }
}