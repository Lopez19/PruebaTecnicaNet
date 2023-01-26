using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaNet.Datos;
using PruebaTecnicaNet.Models;
using System.Data;
using System.Diagnostics;

namespace PruebaTecnicaNet.Controllers
{
    public class HomeController : Controller
    {
        // Contex
        private readonly AplicationDbContex _context;
        public HomeController(AplicationDbContex context)
        {
            _context = context;
        }

        // GET: HomeController
        public IActionResult Index()
        {
            return View();
        }

        // POST: HomeController/Details
        public async Task<IActionResult> Detalles()
        {
            var documento = Request.Form["documento"].ToString();
            var usuario = Request.Form["usuario"].ToString();

            var parameters = new
            {
                @DOC_IDENTIDAD = documento,
                @Evento = 1,
                @Usuario = usuario
            };

            var connection = _context.Database.GetDbConnection();
            var result = await connection.QueryAsync<Nomina>(
                sql: "USP_CONSULTA_NOMINA_POR_DOCUMENTO",
                param: parameters,
                commandType: CommandType.StoredProcedure
                );

            return View(result);
        }

        // PUT: HomeController/Edit
        public async Task<IActionResult> Edit(string id, string usuario, int? val_nomina)
        {

            if (val_nomina != null)
            {
                var parameter = new
                {
                    @DOC_IDENTIDAD = id,
                    @Usuario = usuario,
                    @Evento = 2,
                    @REGISTRO_NOM_NOMINA_DEFINITIVA = val_nomina
                };

                var connection = _context.Database.GetDbConnection();

                connection.Query<Nomina>(
                    sql: "USP_CONSULTA_NOMINA_POR_DOCUMENTO",
                    param: parameter,
                    commandType: CommandType.StoredProcedure
                    );

                return Redirect("/");
            }
            else
            {
                var parameter = new
                {
                    @DOC_IDENTIDAD = id,
                    @Evento = 1,
                };

                var connection = _context.Database.GetDbConnection();

                var resultado = await connection.QueryAsync<Nomina>(
                    sql: "USP_CONSULTA_NOMINA_POR_DOCUMENTO",
                    param: parameter,
                    commandType: CommandType.StoredProcedure
                    );

                return View(resultado);
            }
        }

        // DELETE: HomeController/Delete
        public async Task<IActionResult> Delete(string id, string usuario, int evento)
        {
            if (evento == 3)
            {
                var parameters = new
                {
                    @DOC_IDENTIDAD = id,
                    @Usuario = usuario,
                    @Evento = 3
                };

                var connection = _context.Database.GetDbConnection();

                connection.Query<Nomina>(
                    sql: "USP_CONSULTA_NOMINA_POR_DOCUMENTO",
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                    );

                return Redirect("/");
            }
            else
            {
                var parameters = new
                {
                    @DOC_IDENTIDAD = id,
                    @Evento = 1
                };

                var connection = _context.Database.GetDbConnection();

                var resultado = await connection.QueryAsync<Nomina>(
                    sql: "USP_CONSULTA_NOMINA_POR_DOCUMENTO",
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                    );

                return View(resultado);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}