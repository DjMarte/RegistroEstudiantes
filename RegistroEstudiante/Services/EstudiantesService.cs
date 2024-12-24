using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RegistroEstudiante.DAL;
using RegistroEstudiante.Models;

namespace RegistroEstudiante.Services;

/*
    1. Guardar
    2. Existe (privado)
    3. Insertar (privado)
    4. Modificar (privado)
    5. Buscar
    6. Eliminar
    7. Listar
*/

public class EstudiantesService(Contexto _contexto){
    public async Task<bool> Guardar(Estudiantes estudiante){
        if(! await Existe(estudiante.EstudianteId))
            return await Insertar(estudiante);
        else
            return await Modificar(estudiante);
    }

    private async Task<bool> Existe(int estudianteId)
    {
        return await _contexto.Estudiantes
            .AnyAsync(e => e.EstudianteId == estudianteId);
    }
    public async Task<bool> ExisteMatricula(int estudianteId, string matricula)
    {
        return await _contexto.Estudiantes    // Y == &&, O == ||, diferente !=
            .AnyAsync(e => e.EstudianteId != estudianteId && e.Matricula.Equals(matricula));
    }

    private async Task<bool> Insertar(Estudiantes estudiante)
    {
        _contexto.Estudiantes.Add(estudiante);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Estudiantes estudiante)
    {
        _contexto.Estudiantes.Update(estudiante);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<Estudiantes?> Buscar(int estudianteId){
        return await _contexto.Estudiantes
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.EstudianteId == estudianteId);
    }

    public async Task<bool> Eliminar(int estudianteId){
        return await _contexto.Estudiantes
            .AsNoTracking()
            .Where(e => e.EstudianteId == estudianteId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Estudiantes>> Listar(Expression<Func<Estudiantes, bool>> criterio){
        return await _contexto.Estudiantes
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}