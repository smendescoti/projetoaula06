using ProjetoAula06a.Entities;
using ProjetoAula06a.Helpers;
using ProjetoAula06a.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula06a.Controllers
{
    /// <summary>
    /// Classe para executar o fluxo de cadastro de um contato
    /// </summary>
    public class ContatoController
    {
        public void CadastrarContato()
        {
            try
            {
                Console.WriteLine("\n *** CADASTRO DE CONTATO *** \n");

                //entrada de dados
                var contato = new Contato()
                {
                    IdContato = Guid.NewGuid(),
                    Nome = InputHelper.Get("Entre com o nome do contato....: "),
                    Cpf = InputHelper.Get("Entre com o cpf do contato.....: "),
                    Email = InputHelper.Get("Entre com o email do contato...: "),
                    Telefone = InputHelper.Get("Entre com o telefone do contato: ")
                };

                //verificar se o objeto Contato está correto (validação)
                var validationResult = contato.Validate;

                //verificar se o objeto não possui erros
                if(validationResult.IsValid)
                {
                    var opcao = InputHelper.Get("\nInforme o tipo de arquivo desejado (1-XML ou 2-JSON): ");

                    BaseRepository<Contato> repository;

                    switch(int.Parse(opcao))
                    {
                        case 1: //XML
                            repository = new ContatoRepositoryXml(); //Polimorfismo
                            break;

                        case 2: //JSON
                            repository = new ContatoRepositoryJson(); //Polimorfismo
                            break;

                        default:
                            throw new Exception("Opção inválida!");
                    }

                    //exportar os dados do contato
                    repository.Exportar(contato);

                    if(repository is ContatoRepositoryXml)
                        Console.WriteLine("\nXML gravado com sucesso.");

                    else if(repository is ContatoRepositoryJson)
                        Console.WriteLine("\nJSON gravado com sucesso.");
                }
                else
                {
                    //imprimir os erros de validação
                    Console.WriteLine("\nOcorreram erros de validação no preenchimento dos dados:");
                    foreach(var item in validationResult.Errors)
                    {
                        Console.WriteLine($"\t * {item.ErrorMessage}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha: {e.Message}");
            }
        }
    }
}
