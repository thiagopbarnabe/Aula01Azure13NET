using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExemploStorage
{
    class Aluno : TableEntity
    {
        public Aluno(string ra, string cidade):base(cidade,ra)
        {

        }

        public string Nome { get; set; }
        public string Email { get; set; }

    }
}
