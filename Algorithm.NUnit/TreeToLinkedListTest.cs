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
            var tree = new FacebookProblems.TreeNode(1);
            tree.left = new FacebookProblems.TreeNode(2);
            tree.right = new FacebookProblems.TreeNode(5);
            tree.left.left = new FacebookProblems.TreeNode(3);
            tree.left.right = new FacebookProblems.TreeNode(4);
            tree.right.right = new FacebookProblems.TreeNode(6);
            var prob = new FacebookProblems.TreeToLinkedList();
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
