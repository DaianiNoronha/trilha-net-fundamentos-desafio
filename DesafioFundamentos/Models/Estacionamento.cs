namespace DesafioFundamentos.Models
{
    public class Veiculo
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
    }

    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<Veiculo> veiculos = new List<Veiculo>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            Console.WriteLine("Digite o modelo do veículo para estacionar:");
            string modelo = Console.ReadLine();

            Console.WriteLine("Digite a cor do veículo para estacionar:");
            string cor = Console.ReadLine();

            Veiculo novoVeiculo = new Veiculo
            {
                Placa = placa,
                Modelo = modelo,
                Cor = cor
            };

            veiculos.Add(novoVeiculo);
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            Veiculo veiculo = veiculos.FirstOrDefault(x => x.Placa.ToUpper() == placa.ToUpper());

            if (veiculo != null)
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                if (int.TryParse(Console.ReadLine(), out int horas))
                {
                    decimal valorTotal = precoInicial + precoPorHora * horas;

                    veiculos.Remove(veiculo);

                    Console.WriteLine($"O veículo {veiculo.Modelo} ({placa}) de cor {veiculo.Cor} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Por favor, digite um valor válido para a quantidade de horas.");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"Modelo: {veiculo.Modelo}, Placa: {veiculo.Placa}, Cor: {veiculo.Cor}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
