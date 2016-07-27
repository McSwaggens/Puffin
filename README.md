###What is Puffin?
Puffin is a C/Java like programming language that compiles into PASM.

####Unique features
*__new__* - Keyword that can be used to copy data.
```C++
int a = 123;
int b = 0;
//Copy a to b
b = new a;
//Change a
a = 0
//A should now be 0 and b should now be 123 
print (b);
```

*__\__pasm__* - Allows you to write native PASM code
```C++
uint i = 0;
__pasm {
  set i INT32 123
}
print(i);
```
