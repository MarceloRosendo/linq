using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimeiraQuestao();
            SegundaQuestao();
            TerceiraQuestao();
            QuartaQuestao();
            QuintaQuestao();
        }

        private static void QuintaQuestao()
        {
            Console.WriteLine("Quinta Questao");
            var carrosMaisFrequentes =
                from c in getCarrosList() 
                where c.Modelo.Equals(ModeloMaisFrequente())
                select c;
            Console.WriteLine(carrosMaisFrequentes);
            ListaCarros(carrosMaisFrequentes);
        }

        private static string ModeloMaisFrequente()
        {
            return (from c in getCarrosList()
                group c by new {c.Modelo}
                into CarrosAgrupados
                orderby CarrosAgrupados.Count() descending
                select CarrosAgrupados.Key.Modelo).First();
        }

        private static void QuartaQuestao()
        {
            Console.WriteLine("Quarta Questao");
            var carrosAgrupadosPorModelo = 
                from c in getCarrosList()
                group c by new {c.Modelo}
                into CarrosAgrupadosPorModelo
                select new
                {
                    CarrosAgrupadosPorModelo.Key.Modelo,
                    Qtd = CarrosAgrupadosPorModelo.Count()
                };
            
            
            foreach (var carro in carrosAgrupadosPorModelo)
            {
                Console.WriteLine(carro.Modelo + " - " + carro.Qtd);
            }
        }
        private static void TerceiraQuestao()
        {
            Console.WriteLine("Terceira Questao");
            var carros = from c in getCarrosList() 
                where c.Placa.EndsWith("1") && c.Cor.Equals("Preto")
                select c;
            ListaCarros(carros);
        }
        
        private static void SegundaQuestao()
        {
            Console.WriteLine("Segunda Questao");
            var carros = from c in getCarrosList() 
                         where c.Modelo.Equals("Uno") 
                         select c;
            ListaCarros(carros);
        }

        private static void PrimeiraQuestao()
        {
            Console.WriteLine("Primeira Questao");
            var carros = from c in getCarrosList() select c;
            ListaCarros(carros);
        }

        private static void ListaCarros(IEnumerable<Carro> carros)
        {
            foreach (var carro in carros)
            {
                Console.WriteLine(carro.Ano + " - " + carro.Cor + " - " + carro.Modelo + " - " + carro.Placa);
            }
        }

        private static List<Carro> getCarrosList()
        {
            List<Carro> carros = new List<Carro>();
            carros.Add(new Carro("NEZ1371", "Uno", "Preto", 1999));
            carros.Add(new Carro("HPA2038", "Uno", "Prata", 1998));
            carros.Add(new Carro("LBJ9413", "Uno", "Beje", 1991));
            carros.Add(new Carro("MSJ9148", "Uno", "Magenta", 2001));
            carros.Add(new Carro("LVZ4801", "Uno", "Bonina", 2007));
            carros.Add(new Carro("JEU7008", "Palio", "Preto", 1995));
            carros.Add(new Carro("MRU2219", "Vectra", "Rosa", 1993));
            carros.Add(new Carro("MRU2217", "Vectra", "Verde", 1994));
            carros.Add(new Carro("LVU9916", "Gol", "Branco", 2010));
            carros.Add(new Carro("NAF7361", "Astra", "Preto", 2017));
            carros.Add(new Carro("NAF7362", "Astra", "Azul", 2017));
            carros.Add(new Carro("NAF7363", "Astra", "Rosa", 2017));
            carros.Add(new Carro("NAF7364", "Astra", "Verde", 2017));
            carros.Add(new Carro("NBY2340", "Uno-Mile", "Azul", 2021));

            return carros;
        }
    }
}