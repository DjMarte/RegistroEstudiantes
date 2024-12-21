using Microsoft.EntityFrameworkCore;
using RegistroEstudiante.Models;

namespace RegistroEstudiante.DAL;

public class Contexto : DbContext{

    //     Nombre    //Tipo de dato            // identidicador
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Estudiantes> Estudiantes { get; set; } // Tabla Estudiante
}