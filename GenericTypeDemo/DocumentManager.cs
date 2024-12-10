using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypeDemo
{
    public class DocumentManager<T> where T:IDocument
    {
        private readonly Queue<T> _documents = new Queue<T>();
        public void AddDocument(T document)
        {
            lock (this)
            {
                _documents.Enqueue(document);
            }
        }

        public bool IsDocumentAvailable
        {
            get
            {
                return _documents.Count > 0;
            }
        }
        public T GetDocument()
        {
            T doc = default(T);
            lock (this)
            {
                doc = _documents.Dequeue();
            }

            return doc;
        }
        public void DisplayAllDocuments()
        {
            foreach (var doc in _documents)
            {
                Console.WriteLine(doc.Title);
            }
        }
    }
}
