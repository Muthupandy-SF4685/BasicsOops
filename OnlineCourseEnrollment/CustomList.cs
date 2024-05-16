using System;

namespace OnlineCourseEnrollment
{
    public partial class CustomList<Type>
    {
    // private feild for initialize count and capacity
        private int _count;
        private int _capacity;

        // properties for count and capacity
        public int Count {get{return _count;}}
        public int Capacity {get{return _capacity;}}

        public Type this[int index] {get{return _array[index];} set { _array[index]= value;}}
        
        // create default array
        private Type[] _array;

        // create Default constructor

        public CustomList(){
            _count = 0;
            _capacity =4;
            _array=new Type[_capacity];

        }
       
        // create parameter constructor for fixed size
        public CustomList(int size) {

            _count =0;
            _capacity=size;
            _array = new Type[_capacity];

        }
        
        //  create add method for store objects
        public void Add(Type data){

            if(_count == _capacity){
                IncreaseSize();
                
            }
            _array[_count] = data;
            _count++;
        }
    
       //create method for increase the size of the list dynamically
        public void IncreaseSize(){
            _capacity*=2;

            Type[] temp = new Type[_capacity];
            
            for(int i=0; i<_count; i++){
                temp[i] = _array[i];
            }
            _array = temp;
        }
     
       public void AddRange(CustomList<Type> elements) 
       {

          _capacity = _capacity+elements.Count;

          Type[] temp = new Type[_capacity];
          int k=0;
          for(int i=0; i<_count+elements._count; i++){

            if(i<_count){
                temp[i]=_array[i];
            }
            else if(i>_count){
                temp[i] = elements[k];
                k++;

            }

          }
          _array=temp;
          _count =  _count+elements._count;

       }

       public void RemoveAt(int index){

        for(int i=0; i<_count-1; i++){

            if(i<index){
                _array[i]=_array[i];
            }
            else if(i>=index){
                _array[i]=_array[i+1];
            }

        }
            _count--;

       }

       public void InsertData(int position, Type data){
        _capacity = _capacity+1;

        Type[] temp = new Type[_capacity];

        for(int i=0; i<Count+1; i++){
            if(i<position){
                temp[i] = _array[i];
            }
            else if(i==position){

                temp[i] = data;

            }
            else{
                temp[i] = _array[i-1];
            }

        }

        _array=temp;
        _count=_count+1;
       }
        
    }
}
