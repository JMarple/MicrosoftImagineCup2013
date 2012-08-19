using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imaginecup2013.Input
{
    public class UpdateInput
    {
        UpdateKeyboardInput updateKeyBoard = new UpdateKeyboardInput();

        public void update(Leoni game)
        {
            updateKeyBoard.update(game);
        }
    }
}
