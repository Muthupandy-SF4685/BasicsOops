using System;
using System.Collections;
using System.Data.Common;

namespace OnlineCourseEnrollment
{
    public partial class CustomList<Type> : IEnumerable,IEnumerator
    {
        
        int position;
        public IEnumerator GetEnumerator(){
             position =-1;
            return (IEnumerator)this;

        }

        public bool MoveNext(){
            if(position<_count){
                position++;
                return true;

            }
            Reset();
            return false;
        }

        public void Reset(){
            position = -1;
        }

        public object Current {get{return _array[position];}}
    }
}
