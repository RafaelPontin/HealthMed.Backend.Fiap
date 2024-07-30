namespace HealthMed.Backend.Aplicacao.Comunicacao
{
    public class ResponseResult<TEntity>
    {
        public ResponseResult()
        {
            Status = 200;
            Erros = new List<string>();
        }
        public TEntity Data { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public IList<string> Erros { get; set; }
    }
}
