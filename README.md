# MemoryGame

## "Memory Game" for Windows Desktop with GUI.

The first form will enable the user to configure the board and the player names and types:

* Clicking the "Against a Friend" button will toggle the m_TextBoxFriend.Enabled from false to true and back, and the text in the textbox to empty or "– computer –". The button's text will be toggled between "Against a friend" and "Against Computer".
* Clicking the purple button will browse through the available board sizes in a loop: 4x4, 4x5, 4x6, 5x4, 5x6, 6x4, 6x5, 6x6, 4x4, 4x5, ..
* Clicking the green "Start!" button or the red X button will close the settings form and the main form will be displayed.

After closing the settings forms, the main form will be displayed, with a matrix of buttons, and three lables:
* The form size will be set according to the matrix size.
* Clicking a 'gray' button will display the character that it "holds" and the background will be set to match the current playe's color (green / purple). If this it the second click that revieles a matching pair, the buttons will remain colored, and the current player will continue to a next turn. Otherwise, the buttons will be grayed-out again and the turn will be passed to the opponent.
* Each matching pair will update the score.
* Clicking a colored button will do nothing.
* When game is over (tie / win) message will be displayed (using the MessageBox.Show method) containing the final score and asking the user for another round. IF the user doesn’t want another round, the main form will be closed and the app will terminate. If The user wants another round, the board will be reset to the same settings for another round.


