<?php

session_start();
if ($_POST['m']==''||$_POST['n']==''||$_POST['maximum']==''){
	$grid= makeGrid(3,4,60);
}else if ($_POST['m']>$_POST['n']){
	$grid = makeGrid($_POST['n'],$_POST['m'],$_POST['maximum']);
}else{
	$grid = makeGrid($_POST['m'],$_POST['n'],$_POST['maximum']);
}
//echo $_POST['step'];
$nextPage = fopen("grid.php","w");
//fwrite($nextPage, '<?php'.PHP_EOL);
//fwrite($nextPage, 'include "grid_head.php";'.PHP_EOL);
//fwrite($nextPage, ''.PHP_EOL);
fwrite($nextPage, '<center>'.PHP_EOL);
fwrite($nextPage,'<p>'.$_POST['m'].'x'.$_POST['n'].' grid, '.$_POST['m']*$_POST['n'].' elements</p>'.PHP_EOL);
fwrite($nextPage,'<table width="100%" border="solid medium" style="text-align:center" id="grid">'.PHP_EOL);
$i=$j=0;
foreach($grid as $ROW){
	fwrite($nextPage,"<tr>");
	foreach($ROW as $COL){
		fwrite($nextPage,"<td id='$i $j'>$COL</td>");
		$j++;
	}
	fwrite($nextPage,"</tr>".PHP_EOL);
	$i++;
	$j=0;
}
fwrite($nextPage,'</table><br />'.PHP_EOL);
fwrite($nextPage,'<form>'.PHP_EOL);
fwrite($nextPage,'Search for:'.PHP_EOL);
fwrite($nextPage,'<input type="text" name="search" id="search"><br />'.PHP_EOL);
fwrite($nextPage,'<input type="submit" id="Submit" value="Submit"><br />'.PHP_EOL);
fwrite($nextPage,'</form>'.PHP_EOL);
fwrite($nextPage,'<p>Meaningful operations: <span id="mo"></span></p>'.PHP_EOL);
fwrite($nextPage,'<p>Iterations: <span id="iter"></span></p>'.PHP_EOL);
fwrite($nextPage,'<p>Number exists?: <span id="ans"></span></p>'.PHP_EOL);
fwrite($nextPage, '<p><a href="grid_start.html">Recreate grid</a></p>'.PHP_EOL);
fwrite($nextPage, '</center></div></body>'.PHP_EOL);
fwrite($nextPage, '</html>'.PHP_EOL);

fclose($nextPage);

if ($_POST['step'] == "Yes"){
	include "grid_head.php";
}else{include "grid_head_nostep.php";}
include "grid.php";

function makeGrid($m, $n, $maximumNumber){
	//expected $m to be the smaller dimension, $n to be equal or greater, $maximumNumber is the greatest number randomly generated in grid
	//$genSet = array();
	$grid = array(array());
	$lastNumber = 1;
	$baseNumber = $row = $col = 0;
	//$x<$m*$n
	for($x=0;$x<$m*$n;$x++){
		//make an ordered array of elements to place in grid
		$lastNumber = rand(floor($maximumNumber/($m*$n)*($x)),floor($maximumNumber/($m*$n)*($x+1)));
		//echo $lastNumber." ";
		//place number in grid
		//first and last (m(m-1))/2 elements special case
		//base number increase moves diag distribution one row over
		$grid[$row][$col] = $lastNumber;
		$row++;
		$col--;		
		if($x < ($m*($m-1))/2){
			//time to move base over
			if($col<0){
				$baseNumber++;
				$row=0;
				$col = $baseNumber;
			}
		}else{
			//time to move base over but special care for last elements
			if($row==$m){
				$baseNumber++;
				if($baseNumber<$n){
					$row=0;
					$col = $baseNumber;
				}else{
					$row=$baseNumber+1-$n;
					$col = $n;
				}
			}
		}
		
	}
	return $grid;
}