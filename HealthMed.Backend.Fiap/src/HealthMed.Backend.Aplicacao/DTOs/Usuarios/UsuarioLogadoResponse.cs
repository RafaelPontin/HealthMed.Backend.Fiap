﻿namespace HealthMed.Backend.Aplicacao.DTOs.Usuarios
{
    public class UsuarioLogadoResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string AccessToken { get; set; }        
    }
}
