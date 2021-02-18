using BlueModas.Libraries.Seguranca;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;

namespace BlueModas.Libraries.Cookie
{
    public class GerenciadorCookie
    {
        private IHttpContextAccessor _context;
        private IConfiguration _conf;

        public GerenciadorCookie(IHttpContextAccessor context,IConfiguration configuration)
        {
            _context = context;
            _conf = configuration;
        }

        public void Cadastrar(string Key, string valor)
        {
            var options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(7);
            options.IsEssential = true;

            var ValorCrypt = StringCipher.Encrypt(valor, _conf.GetValue<string>("CryptKey"));

            _context.HttpContext.Response.Cookies.Append(Key, ValorCrypt, options);
        }

        public string Consultar(string Key,bool Crypt=true)
        {
            var Valor = _context.HttpContext.Request.Cookies[Key];
            if(Crypt)
                Valor = StringCipher.Decrypt(Valor, _conf.GetValue<string>("CryptKey"));
            return Valor;
        }
        public bool Existe(string Key)
        {
            if (_context.HttpContext.Request.Cookies[Key] == null) return false;
            return true;
        }

    }
}
