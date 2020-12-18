namespace eVenda.Estoque.Model
{
	public class RequestErrorModel
	{
		public string Propriedade { get; }
		public string Mensagem { get; }


		public RequestErrorModel(string propriedade, string mensagem)
		{
			Propriedade = propriedade;
			Mensagem = mensagem;
		}

	}
}
