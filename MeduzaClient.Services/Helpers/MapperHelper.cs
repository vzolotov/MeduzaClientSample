using AutoMapper;
using MeduzaClient.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MeduzaClient.Models;

namespace MeduzaClient.Services.Helpers
{
    internal class MapperHelper
    {
        public static IEnumerable<DocumentEntity> MapToEntityArray(IEnumerable<Document> source)
        {
            return source.Select(x => new DocumentEntity
            {
                Id = 0,
                document_type = x.document_type,
                full = x.full,
                modified_at = x.modified_at,
                published_at = x.published_at,
                pub_date = x.pub_date,
                title = x.Title,
                url = x.url,
                version = x.version
            });
        }

        public static IEnumerable<Document> MapToDocArray(IEnumerable<DocumentEntity> source)
        {
            return source.Select(x => new Document
            {
                document_type = x.document_type,
                full = x.full,
                modified_at = x.modified_at,
                published_at = x.published_at,
                pub_date = x.pub_date,
                Title = x.title,
                url = x.url,
                version = x.version
            });
        }
    }
}
