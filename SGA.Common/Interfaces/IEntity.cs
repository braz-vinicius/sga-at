namespace SGA.Common.Interfaces
{
    /// <summary>
    /// Interface que representa um entidade de domínio com chave primária do tipo <typeparamref name="TKey"/>
    /// </summary>
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}