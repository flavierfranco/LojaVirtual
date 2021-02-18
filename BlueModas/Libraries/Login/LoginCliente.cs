using BlueModas.Models;
using Newtonsoft.Json;

namespace BlueModas.Libraries.Login
{
    public class LoginCliente
    {
        private string Key = "Login.Cliente";
        private Sessao.Sessao _sessaoCliente;

        public LoginCliente(Sessao.Sessao sessao)
        {
            _sessaoCliente = sessao;
        }
        //CRIA UMA SESSAO COM O OBJETO TRANSFORMADO EM STRING
        public void CriarLogin(Cliente cliente)
        {
            string DataCliente = JsonConvert.SerializeObject(cliente);
            _sessaoCliente.Cadastrar(Key, DataCliente);
        }
        //TRATA A STRING CRIADA NA SESSAO E RETORNA O OBJ
        public Cliente BuscaClienteSessao()
        {
            string ClienteJson = _sessaoCliente.Consultar(Key);
            if(ClienteJson!=null)
                return JsonConvert.DeserializeObject<Cliente>(ClienteJson);
            return null;
        }

    }
}
