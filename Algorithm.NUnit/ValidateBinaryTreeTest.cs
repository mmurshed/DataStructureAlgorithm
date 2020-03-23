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
            var tree = new Facebook.ValidateBinaryTree.TreeNode(5);
            tree.left = new Facebook.ValidateBinaryTree.TreeNode(1);
            tree.right = new Facebook.ValidateBinaryTree.TreeNode(4);
            tree.right.left = new Facebook.ValidateBinaryTree.TreeNode(3);
            tree.right.right = new Facebook.ValidateBinaryTree.TreeNode(6);
            var prob = new Facebook.ValidateBinaryTree();
            var expected = false;

            // Act
            var actual =prob.IsValidBST(tree);

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
