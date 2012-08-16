using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imaginecup2013.Input
{
    class UpdateInput
    {
        UpdateKeyboardInput updateKeyBoard = new UpdateKeyboardInput();

        public void update(Leoni game)
        {
            updateKeyBoard.update(game);
        }
    }
}
