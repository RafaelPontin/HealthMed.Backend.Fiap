namespace HealthMed.Backend.Dominio.Entidades
{
    public abstract class Base
    {
        public Guid Id { get; private set; }
        public IList<string> Erros { get; private set; }

        public Base()
        {
            Id = Guid.NewGuid();
            Erros = new List<string>();
        }
        protected void DefinirId(Guid id)
        {
            Id = id;
        }

        protected void AddErro(string erro)
        {
            if (!string.IsNullOrWhiteSpace(erro))
                Erros.Add(erro);
        }
    }
}
