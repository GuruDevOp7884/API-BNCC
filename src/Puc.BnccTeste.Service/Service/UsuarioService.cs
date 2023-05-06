﻿using Puc.BnccTeste.Service.Interface;
using Puc.BnccTeste.Infra.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Puc.BnccTeste.Domain.Entidade;
using BCrypt.Net;
using Puc.BnccTeste.Domain.ObjetoValor;
using Puc.BnccTeste.Api.DTOs;
using Puc.BnccTeste.Infra.CrossCutting.DI.Util;

namespace Puc.BnccTeste.Service.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepositorio _UserRepo;
        private bool disposedValue;

        public UsuarioService(IUsuarioRepositorio userRepo)
        {
            _UserRepo = userRepo;
        }

        public IEnumerable<Usuario> ListarUsuariosAtivos()
        {
            return _UserRepo.ListarTodos().Where(x => x.Ativo == true);
        }

        public bool Atualizar(Usuario usuario)
        {            
            var result = _UserRepo.Atualizar(usuario);
            return result;
        }

        public bool Deletar(int id)
        {
            try
            {
                if(id > 0)
                {
                    var result = _UserRepo.ObterPeloId(id);
                    result.Ativo = false;
                    _UserRepo.Atualizar(result);
                    return true;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }      

        public bool Inserir(Usuario usuario)
        {
            try
            {
                if (usuario != null)
                {
                    usuario.Ativo = true;
                    bool result = _UserRepo.Inserir(usuario);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return false; 
        }

        public ContractorResult Login(LoginUsuario usuario)
        {
            ContractorResult retorno = new ContractorResult();

            try
            {
                if (retorno.AcaoValida = Utils.ValidarEmail(usuario.Email))
                {
                    var usuarios = ListarUsuariosAtivos().FirstOrDefault(x => x.Email == usuario.Email);

                    if (usuarios != null)
                    {
                        retorno.AcaoValida = BCrypt.Net.BCrypt.Verify(usuario.Senha, usuarios.Senha);

                        if (retorno.AcaoValida)
                        {
                            retorno.Message = "Usuário encontrado";
                        }
                        else
                        {
                            retorno.Message = "Email/Senha inválidos";
                        }
                    }
                    else
                    {
                        retorno.Message = "Por favor digite um Email e Senha";
                    }
                }
                else
                {
                    retorno.Message = "Email inválido";
                }
            }
            catch (Exception ex)
            {
                retorno.AcaoValida = false;
                retorno.Message = "Erro durante a operação: " + ex;
            }
            return retorno;
        }

        public ContractorResult Registrar(Usuario usuario)
        {
             ContractorResult retorno = new ContractorResult();

            try
            {
                retorno.AcaoValida = Utils.ValidarEmail(usuario.Email);

                if (retorno.AcaoValida && usuario.Senha != "" && usuario.Nome != "")
                {
                    usuario.Ativo = true;
                    usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);

                    retorno.AcaoValida = _UserRepo.Inserir(usuario);
                    retorno.Message = "Usuário registrado com sucesso";
                    
                }
                else if (retorno.AcaoValida != true)
                {
                    retorno.Message = "Email inválido";
                }
            }
            catch (Exception ex)
            {
                retorno.AcaoValida = false;
                retorno.Message = "Erro durante a operação: " + ex;
            }
            return retorno;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}