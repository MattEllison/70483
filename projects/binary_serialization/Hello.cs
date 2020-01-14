using System;

namespace binary_serialization
{
    [Serializable]
    class Hello
    {
        public Hello(string name)
        {
            Name = name;
        }
        public Hello()
        {

        }

        public string Name { get; set; }
    }
}
