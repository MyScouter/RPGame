<p><strong>RPG - Game:</strong></p>
<p><strong>Description:</strong></p>
<p>Simple RPG game in which the player walks around the map and his/her primary objective is to kill all the enemies. the player can collect different items and use them to his/her advantage.&nbsp;</p>
<p><strong>Game Controls:</strong></p>
<p><strong>-&nbsp;</strong><strong>Mouse Right-Click:&nbsp;</strong>in order to collect items and attack enemies.</p>
<p><strong>- Mouse Left-Click:&nbsp;</strong>the player will move towards the desired location when clicked.</p>
<p><strong>- i/b:</strong> in order to open/close the player's inventory to view and equip items.</p>
<p><strong>- u:</strong> in order to un-equip all the items.</p>
<p><strong>- Scroll in/out:&nbsp;</strong>in order to zoom in and out on the player.</p>
<p><strong>- a/d:</strong> in order to look left and right of the player.</p>
<p><img src="https://github.com/MyScouter/RPGame/blob/master/gif/PlayerMovment.gif" alt="PlayerMovment" /></p>
<p><img src="https://github.com/MyScouter/RPGame/blob/master/gif/camera.gif" alt="camera" /></p>
<p>In this game, we've implemented different concepts and used different powerful tools such as delegates, Singelton instances, UI managers, Logic managers. We've created virtual methods and generic classes and separated the use and responsibility of our scripts.</p>
<p>The player has 6 different scripts controlling different aspects of the player's functionalities. you can dig dipper into them in order to have a better understanding:</p>
<p><a href="RPG project/Assets/Scripts/Controller/PlayerController.cs">PlayerController</a>&nbsp;- In charge of the player's movement.<br /><a href="RPG project/Assets/Scripts/Controller/PlayerMotor.cs">PlayerMotor</a>&nbsp;- In charge of the navigation and different movement aspects.<br /><a href="RPG project/Assets/Scripts/Stats/PlayerStats.cs">PlayerStats</a>&nbsp;- In charge of modifying the player's damage, armor and health.<br /><a href="RPG project/Assets/Scripts/PlayerAnimator.cs">PlayerAnimator</a>&nbsp;- In charge of animating the equipment the player uses and using the right animation accordingly.<br /><a href="RPG project/Assets/Scripts/PlayerManager.cs">PlayerManager</a>&nbsp;- In charge of ending and restarting the game.<br /><a href="RPG project/Assets/Scripts/HealthUI.cs">HealthUI</a>&nbsp;- In charge of the health bar UI.<br /><a href="RPG project/Assets/Scripts/CharacterCombat.cs">CharacterCombat</a>&nbsp;- In charge of different aspects of a fight.</p>
<p><img src="https://github.com/MyScouter/RPGame/blob/master/gif/attack.gif" alt="combat" /></p>
<p>There are a lot of other scripts, such as base scripts for describing an item, deriving scripts. different scripts for the inventory and more.</p>
<p><img src="https://github.com/MyScouter/RPGame/blob/master/gif/invnt%26take.gif" alt="take" /></p>
<p><img src="https://github.com/MyScouter/RPGame/blob/master/gif/equip%26unequip.gif" alt="equip" /></p>
