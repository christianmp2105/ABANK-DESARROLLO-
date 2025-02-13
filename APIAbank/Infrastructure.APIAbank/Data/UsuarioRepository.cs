using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.APIAbank.Interfaces;
using Core.APIAbank.Repository;
using Dapper;

namespace Infrastructure.APIAbank.Data
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDbConnection _dbConnection;
        public UsuarioRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            string query = "SELECT * FROM Usuarios WHERE id=@id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Usuario>(query, new { id=id });
        }
        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            string query = "SELECT * FROM Usuarios";
            return await _dbConnection.QueryAsync<Usuario>(query);
        }

        public async Task AddAsync(Usuario usuario)
        {
            string query = "INSERT INTO Usuarios(nombres,apellidos,fechanacimiento,direccion,contraseña,telefono,email,fechacreacion,fechamodificacion)" +
                "VALUES (@nombres,@apellidos,@fechanacimiento,@direccion,@contraseña,@telefono,@email,@fechacreacion,@fechamodificacion)";
             await _dbConnection.ExecuteAsync(query, usuario);
        }
        public async Task UpdateAsync(Usuario usuario)
        {
            string query = "UPDATE Usuarios SET nombres=@nombres, apellidos=@apellidos, fechanacimiento=@fechanacimiento,direccion=@direccion,contraseña=@contraseña," +
                "telefono=@telefono,email=@email,fechacreacion=@fechacreacion,fechamodificacion=@fechamodificacion WHERE id=@id";
            await _dbConnection.ExecuteAsync(query,usuario);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "DELETE FROM Usuarios WHERE id=@id";
            await _dbConnection.ExecuteAsync(query, new { id = id });    
        }


    }
}
