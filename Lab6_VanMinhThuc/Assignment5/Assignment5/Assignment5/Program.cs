namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Wrap services with caching decorator
            IService cachedProductService = new CacheDecorator(new ProductService());
            IService cachedUserService = new CacheDecorator(new UserService());

            // Test ProductService
            Console.WriteLine(cachedProductService.Get(1)); // Fetches from DB
            Console.WriteLine(cachedProductService.Get(1)); // Fetches from cache

            // Test UserService
            Console.WriteLine(cachedUserService.Get(2));    // Fetches from DB
            Console.WriteLine(cachedUserService.Get(2));    // Fetches from cache
        }
    }
}