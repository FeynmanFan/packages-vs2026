namespace ourcompany.businesslibrary
{
    public record Person
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public string? Email { get; init; }
        public DateTime? BirthDate { get; init; }
    }
}
