using Base.Api.Utils;
using Base.Model.Dtos;
using Base.Model.Models;
using Base.Service.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Xml;

namespace Base.Api.Controllers.Api
{
    public class SolicitudesController : ApiController
    {
        private readonly ICertificadoService _certificadoService;
        private readonly ICertificadoConsumoMasivoService _certificadoConsumoMasivoService;
        private readonly ISustanciaService _sustanciaService;
        private readonly IUserTokenService _userTokenService;
        private readonly ILogConsultaService _logConsultaService;
        private readonly ITipoFallaService _tipoFallaService;
        private readonly IMovimientoService _movimientoService;
        private readonly ILicenciaService _licenciaService;
        private readonly IVisitaAnexoService _visitaAnexoService;
        private readonly ILicenciasEstadoService _licenciasEstadoService;

        private static TraceSource mySource = new TraceSource("MICC_Api");

        public SolicitudesController(ICertificadoService certificadoService, 
                                     ISustanciaService sustanciaService, 
                                     IUserTokenService userTokenService, 
                                     ILogConsultaService logConsultaService,
                                     ITipoFallaService  tipoFallaService,
                                     ICertificadoConsumoMasivoService certificadoConsumoMasivoService,
                                     IMovimientoService movimientoService,
                                     ILicenciaService licenciaService,
                                     ILicenciasEstadoService licenciasEstadoService,
                                     IVisitaAnexoService visitaAnexoService
                                    )
        {
            _certificadoService = certificadoService;
            _sustanciaService = sustanciaService;
            _userTokenService = userTokenService;
            _logConsultaService = logConsultaService;
            _tipoFallaService = tipoFallaService;
            _certificadoConsumoMasivoService = certificadoConsumoMasivoService;
            _movimientoService = movimientoService;
            _licenciaService = licenciaService;
            _licenciasEstadoService = licenciasEstadoService;
            _visitaAnexoService = visitaAnexoService;
        }

        [Route("api/Solicitud/GetEstadoLicencias")]
        [HttpPost]
        public async Task<IHttpActionResult> GetEstadoLicencias()
        {
            try
            {
               
                List<Licencia> licencias = new List<Licencia>();
                LicenciaDto licenciaDto = new LicenciaDto();

                var userid = "";

                var _token = GetToken();

                mySource.TraceInformation($"Validando Token {_token}");

                var resultValidation = ValidateToken(_token, ref userid);

                if (!resultValidation) { mySource.TraceEvent(TraceEventType.Information, 3, $"Token invalido {_token}"); throw new Exception("Token invalido"); }

                // Agregar validación para NroDocSoporte
                if (!(string.IsNullOrEmpty(_token) || _token == null))
                    //licencias = _licenciaService.Execute("ConsultaEstadoLicencias", new Licencia() { Token = _token, IdUser = userid }).ToList();
                    _licenciasEstadoService.Execute("Consulta", new LicenciasEstado() { Token = _token, IdUser = userid, Licencias = licencias });


                mySource.TraceInformation($"Visitas obtenidas {JsonConvert.SerializeObject(licencias)}");

                if (licencias == null || licencias.Count <= 0) return NotFound();

                licenciaDto.Licencias = licencias;


               // var logId = _logConsultaService.Create(new LogConsulta() { NroDocSoporte = movimientoDto.NroDocSoporte, IdUsuario = userid, Latitude = movimientoDto.Location.Latitude, Longitude = movimientoDto.Location.Longitude });

                //movimientoDto.IdConsulta = Convert.ToInt64(logId);

                //mySource.TraceEvent(TraceEventType.Information, 10, $"Retorno {JsonConvert.SerializeObject(movimientoDto)}");

                return Ok(licenciaDto);

            }
            catch (Exception ex)
            {
                mySource.TraceEvent(TraceEventType.Error, 99, ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
            finally
            {
                mySource.Flush();
            }

        }

        [Route("api/Solicitud/GetEstadoCupos")]
        [HttpPost]
        public async Task<IHttpActionResult> GetEstadoCupos()
        {
            try
            {
                List<Cupo> cupos = new List<Cupo>();
                CupoDto cupoDto = new CupoDto();

                var userid = "";

                var _token = GetToken();

                mySource.TraceInformation($"Validando Token {_token}");

                var resultValidation = ValidateToken(_token, ref userid);

                if (!resultValidation) { mySource.TraceEvent(TraceEventType.Information, 3, $"Token invalido {_token}"); throw new Exception("Token invalido"); }

                // Agregar validación para NroDocSoporte
                if (!(string.IsNullOrEmpty(_token) || _token == null))
                    cupos = _cupoService.Execute("ConsultaEstadoCupos", new Cupo() { Token = _token, IdUser = userid }).ToList();


                mySource.TraceInformation($"Visitas obtenidas {JsonConvert.SerializeObject(cupos)}");

                if (cupos == null || cupos.Count <= 0) return NotFound();

                cupoDto.Cupos = cupos;


                // var logId = _logConsultaService.Create(new LogConsulta() { NroDocSoporte = movimientoDto.NroDocSoporte, IdUsuario = userid, Latitude = movimientoDto.Location.Latitude, Longitude = movimientoDto.Location.Longitude });

                //movimientoDto.IdConsulta = Convert.ToInt64(logId);

                //mySource.TraceEvent(TraceEventType.Information, 10, $"Retorno {JsonConvert.SerializeObject(movimientoDto)}");

                return Ok(cupoDto);

            }
            catch (Exception ex)
            {
                mySource.TraceEvent(TraceEventType.Error, 99, ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
            finally
            {
                mySource.Flush();
            }

        }

        private string GetToken(string tokenType="Bearer")
        {
            mySource.TraceEvent(TraceEventType.Information, 2, $"Recuperando token {tokenType}");

            string authHeader = HttpContext.Current.Request.Headers["Authorization"];

            if (authHeader == null || !authHeader.StartsWith(tokenType))
            {
                mySource.TraceEvent(TraceEventType.Information, 2, "Token vacío");
                throw new Exception("Token vacío");
            }

            string token= authHeader.Substring($"{tokenType} ".Length).Trim();

            mySource.TraceEvent(TraceEventType.Information, 2, $"Token recuperado {token}");

            return token;

        }

        private bool ValidateToken(string token, ref string userid)
        {
            var result = _userTokenService.Execute("ValidateToken", new UserToken() { IdToken = token }).ToList();

            if (result != null && result.Count() > 0)
            {
                if (!string.IsNullOrEmpty(result[0].IdToken))
                {
                    userid = result[0].IdUsuario;
                    return true;
                }
            }
            
            return false;
        }

        private long GetCertificateIdFromCcite(int ccite)
        {
            var result = _certificadoService.Execute("GetCertificateIdFromCcite", new Certificado() { NoCcite = ccite }).ToList();

            if (result != null && result.Count() > 0)
            {
               return result[0].IdCertificado;                
            }

            return 0;
        }

        private long GetCertificateIdFromCcitePorQr(string qr)
        {
            var result = _certificadoService.Execute("GetCertificateIdFromCcitePorQr", new Certificado() { CodigoSeguridad = qr }).ToList();

            if (result != null && result.Count() > 0)
            {
                return result[0].IdCertificado;
            }

            return 0;
        }

      }

}
