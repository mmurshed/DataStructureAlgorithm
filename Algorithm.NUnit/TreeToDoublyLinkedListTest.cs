using NUnit.Framework;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class TreeToDoublyLinkedListTest
    {
        [Test]
        public void Test()
        {
            // Arrange
            var tree = new FacebookProblems.Node(4);
            tree.left = new FacebookProblems.Node(2);
            tree.right = new FacebookProblems.Node(5);
            tree.left.left = new FacebookProblems.Node(1);
            tree.left.right = new FacebookProblems.Node(3);
            var prob = new FacebookProblems.TreeToDoublyLinkedList();
            var expected = new int[] {1, 2, 3, 4, 5};

            // Act
            var result = prob.TreeToDoublyList(tree);

            // Assert
            int[] actual = new int[expected.Length];
            for (int i = 0; i < expected.Length; i++)
            {
                actual[i] = result.val;
                result = result.right;
            }

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            // Arrange
            var tree = new FacebookProblems.Node(-7);
            tree.left = new FacebookProblems.Node(-8);
            tree.left.left = new FacebookProblems.Node(-9);
            tree.right = new FacebookProblems.Node(-6);
            tree.right.right = new FacebookProblems.Node(-5);
            var prob = new FacebookProblems.TreeToDoublyLinkedList();
            var expected = new int[] { -9, -8, -7, -6, -5 };

            // Act
            var result = prob.TreeToDoublyList(tree);

            // Assert
            int[] actual = new int[expected.Length];
            for (int i = 0; i < expected.Length; i++)
            {
                actual[i] = result.val;
                result = result.right;
            }

            CollectionAssert.AreEqual(expected, actual);
        }

    }
}
