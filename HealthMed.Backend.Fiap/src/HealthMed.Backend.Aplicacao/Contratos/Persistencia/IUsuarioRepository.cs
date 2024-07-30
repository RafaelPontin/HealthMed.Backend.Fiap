﻿using HealthMed.Backend.Dominio.Entidades;

namespace HealthMed.Backend.Aplicacao.Contratos.Persistencia
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<Usuario> ObterPorEmail(string email);
    }
}