using NUnit.Framework;
using System.Collections.Generic;

using Algorithm.Tree.Problems.NAryCodec;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class NAryTreeCodecTest
    {
        [TestCase]
        public void Test()
        {
            // Arrange
            var root = new Node(1, new List<Node>());
            var three = new Node(3, new List<Node>());
            var two = new Node(2, new List<Node>());
            var four = new Node(4, new List<Node>());

            three.children.Add(new Node(5, new List<Node>()));
            three.children.Add(new Node(6, new List<Node>()));

            root.children.Add(three);
            root.children.Add(two);
            root.children.Add(four);

            var codec = new Codec();

                                  
            // Act
			var data = codec.serialize(root);
            var result = codec.deserialize(data);

            // Assert
            Assert.True(AreEqual(root, result));
        }

        public bool AreEqual(Node left, Node right)
        {
            if (left == null && right == null)
                return true;
            else if (left == null && right != null)
                return false;
            else if (left != null && right == null)
                return false;
            else if (left.val != right.val)
                return false;

            if (left.children == null && right.children == null)
                return true;
            else if (left.children != null && right.children == null)
                return false;
            else if (left.children == null && right.children != null)
                return false;
            else if (left.children.Count != right.children.Count)
                return false;

            var leften = left.children.GetEnumerator();
            var righten = right.children.GetEnumerator();

            while(leften.MoveNext() && righten.MoveNext())
            {
                bool cmp = AreEqual(leften.Current, righten.Current);
                if (!cmp)
                    return false;
            }

            return true;
        }

	}
}
