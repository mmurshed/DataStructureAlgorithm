using NUnit.Framework;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class TreeToLinkedListTest
    {
        [Test]
        public void Test()
        {
            // Arrange
            var tree = new Facebook.TreeNode(1);
            tree.left = new Facebook.TreeNode(2);
            tree.right = new Facebook.TreeNode(5);
            tree.left.left = new Facebook.TreeNode(3);
            tree.left.right = new Facebook.TreeNode(4);
            tree.right.right = new Facebook.TreeNode(6);
            var prob = new Facebook.TreeToLinkedList();
            var expected = new int[] {1, 2, 3, 4, 5, 6};

            // Act
            prob.Flatten(tree);

            // Assert
            int[] actual = new int[expected.Length];
            for (int i = 0; i < expected.Length; i++)
            {
                actual[i] = tree.val;
                tree = tree.right;
            }

            CollectionAssert.AreEqual(expected, actual);
        }

    }
}
