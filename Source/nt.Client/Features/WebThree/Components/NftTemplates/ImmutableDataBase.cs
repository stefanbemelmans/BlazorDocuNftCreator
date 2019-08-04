using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TypeSupport.Extensions;

namespace nt.Client.Features.WebThree.Components.NftTemplates
{
    public class ImmutableDataObjectBase
    {
        public ImmutableDataObjectBase()
        {
            //TokenProps = GetProps();

        }

        private List<KeyValuePair<string, object>> TempList { get; set; }
        public List<KeyValuePair<string, object>> TokenProps { get; set; }
        public uint TokenId { get; set; }
        public uint NftId { get; set; }
        public

        List<KeyValuePair<string, object>> GetProps()
        {
            TempList = new List<KeyValuePair<string, object>>();
            foreach (var propName in this.GetProperties(0)) // That 0 is GetProperty Options
            {
                var item = new KeyValuePair<string, object>(propName.Name, this.GetPropertyValue(propName.Name, propName.Type));

                TempList.Add(item);

            }
            return TempList;
        }

        //public object Current => throw new NotImplementedException();

        //public IEnumerator<string> GetEnumerator()
        //{
        //    return (IEnumerator)this;
        //}

        //public bool MoveNext()
        //{
        //    position++;
        //    return (position < carlist.Length);
        //}

        //public void Reset()
        //{
        //    throw new NotImplementedException();
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
