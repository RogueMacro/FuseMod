using System;

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
        string Syntax { get; }
        string Description { get; }

        void Execute(string[] args);
    }
}
