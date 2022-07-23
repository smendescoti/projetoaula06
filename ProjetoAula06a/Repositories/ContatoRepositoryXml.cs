using ProjetoAula06a.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjetoAula06a.Repositories
{
    /// <summary>
    /// Classe para exportação de dados de contato para arquivo XML
    /// </summary>
    public class ContatoRepositoryXml : BaseRepository<Contato>
    {
        public override void Exportar(Contato obj)
        {
            //serializar os dados para o formato XML
            var xml = new XmlSerializer(typeof(Contato));

            //criando um arquivo de extensão XML
            using (var streamWriter = new StreamWriter($"c:\\temp\\contato_{obj.IdContato}.xml"))
            {
                //escrevendo o conteudo do arquivo
                xml.Serialize(streamWriter, obj);   
            }
        }
    }
}
