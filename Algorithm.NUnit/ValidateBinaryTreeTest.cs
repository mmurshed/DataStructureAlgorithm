using NUnit.Framework;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class ValidateBinaryTreeTest
    {
        [Test]
        public void Test()
        {
            // Arrange
            var tree = new FacebookProblems.ValidateBinaryTree.TreeNode(5);
            tree.left = new FacebookProblems.ValidateBinaryTree.TreeNode(1);
            tree.right = new FacebookProblems.ValidateBinaryTree.TreeNode(4);
            tree.right.left = new FacebookProblems.ValidateBinaryTree.TreeNode(3);
            tree.right.right = new FacebookProblems.ValidateBinaryTree.TreeNode(6);
            var prob = new FacebookProblems.ValidateBinaryTree();
            var expected = false;

            // Act
            var actual =prob.IsValidBST(tree);

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
