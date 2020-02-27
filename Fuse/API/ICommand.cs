using Fuse.Core.Commands;

namespace Fuse.API
{
    public interface ICommand
    {
        /// <summary>
        ///     <para>The name of the command which will be used to execute it.</para>
        ///     <para>This property will override other commands aliases.</para>
        ///     <para>The name of the broadcast command is "Broadcast", so you do /broadcast to execute it.</para>
        ///     <para><b>This property can't be null.</b></para>
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     <para>Aliases, often shorter names, of the command which can be used to execute it.</para>
        ///     <para>An alias of the broadcast command could be "bc".</para>
        /// </summary>
        string[] Aliases { get; }

        /// <summary>
        ///     <para>The syntax for how the command should be used</para>
        ///     <para>This may be shown if an user does a help command</para>
        ///     <para>An example can be "/broadcast &lt;message&gt;"</para>
        /// </summary>
        string Syntax { get; }

        string Description { get; }

        bool Enabled { get; }

        CommandResult Execute(string[] args);
    }
}
