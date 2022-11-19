
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PaparaRepositoryPattern.Data.Abstarcts;
using PaparaRepositoryPattern.Domain;
using PaparaRepositoryPattern.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaparaRepositoryPattern.Data.Concretes
{
    public class CompanyDapperRepository : ICompanyDapperRepository
    {

        private readonly IConfiguration configuration;

        public CompanyDapperRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Add new company
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public async Task<int> Add(Company company)
        {
            var sql = "Insert into Companies (CreationDate, DeleteDate,Status ,Name ,Adress ,City ,TaxNumber, Email) VALUES (@CreationDate, @DeleteDate, @Status, @Name, @Adress, @City, @TaxNumber, @Email)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, company);
                return result;
            }
        }

        /// <summary>
        /// Delete company
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> Delete(int id)
        {
            var sql = " DELETE FROM[dbo].[Companies] WHERE Id= @Id";

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        /// <summary>
        /// List all companies
        /// </summary>
        /// <returns></returns>
        public async Task<List<Company>> GetAll()
        {
            var sql = "SELECT * FROM Companies";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Company>(sql);
                return result.ToList();
            }
        }

        /// <summary>
        /// Get company by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Company> GetById(int id)
        {
            var sql = "Select * From Companies WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Company>(sql, new { Id = id });
                return result;
            }
        }

        /// <summary>
        /// Update company
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public async Task<int> Update(Company company)
        {
            var sql = "UPDATE Companies SET Name =@Name , Adress=@Adress, City=@City, TaxNumber=@TaxNumber, Email=@Email  WHERE Id =@Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, company);
                return result;
            }
        }
    }
}
