using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests {
    [TestFixture]
  public  class StackTests {
        [Test]
        public void Push_ArgIsNull_ThrowsArgNullException()
        {
            var stack = new Stack<string>();

            Assert.That(()=>stack.Push(null),Throws.ArgumentNullException);

        }

        [Test]
        public void Push_ArgIsValid_AddedToTheStack()
        {
            var stack = new Stack<string>();

            stack.Push("New");

            Assert.That(stack.Count,Is.EqualTo(1));

        }

        [Test]
        public void Count_EmptyStack_ReturnZero()
        {
            var stack = new Stack<string>();
            Assert.That(stack.Count,Is.EqualTo(0));
        }

        [Test]
        public void Pop_EmptyStack_ThrowInvalidOperationException()
        {
            var stack = new Stack<string>();
            Assert.That(()=>stack.Pop(),Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_StackWithaFewObjects_ReturnObjectOnTheTop()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            var result = stack.Pop();
            Assert.That(result,Is.EqualTo("c"));
        }

        [Test]
        public void Pop_StackWithaFewObjects_RemoveObjectOnTheTop()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            var result = stack.Pop();


            Assert.That(stack.Count,Is.EqualTo(2));
        }

        [Test]
        public void Peek_StackWithNoObjects_ThrowsInvalidErrorException()
        {
            //Arrange 
            //Empty stack
            //Try to peek an empty stack and then we see an error
            var stack = new Stack<string>();          
          //  var result = stack.Peek();

            Assert.That(()=>stack.Peek(),Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_StackWithMultipleObjects_DoesNotRemoveObjectFromStack()
        {
            //Arrange 
            //Empty stack
            //Try to peek an empty stack and then we see an error
            var stack = new Stack<string>();          
            //  var result = stack.Peek();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            stack.Peek();           
            Assert.That(stack.Count,Is.EqualTo(3));

        }

        [Test]
        public void Peek_StackWithMultipleObjects_ReturrnsLastObject()
        {
            //Arrange 
            //Empty stack
            //Try to peek an empty stack and then we see an error
            var stack = new Stack<string>();          
            //  var result = stack.Peek();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            var result =   stack.Peek();           
            Assert.That(result,Is.EqualTo("c"));
            
        }
        

    }


}
