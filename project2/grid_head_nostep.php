<!DOCTYPE html>
<html lang="en">
  <head><meta charset="utf-8" /><meta http-equiv="X-UA-Compatible" content="IE=edge" />
	<title>Grid</title>
	<meta name="viewport" content="width=device-width, initial-scale=1" />
	<link href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css" rel="stylesheet">
	<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
	

	<script>
	$(document).ready(function()
		{
			$('#Submit').click(function()
			{
				$("#grid tbody tr td").css("background-color","white");
				var search=$("#search").val();
				var row_start=$("#grid tr").length - 1;
				var col_max=($("#grid tr td").length/$("#grid tr").length) - 1;
				var col_start=0;
				var calc_count=iteration=0;
				var found=false;
				while(!(found)){	
//alert($("#grid tbody tr:eq("+row_start+") td:eq("+col_start+")").text());	
					var current_position = $("#grid tbody tr:eq("+row_start+") td:eq("+col_start+")").text()
					calc_count++;
					iteration++;
						
					if(parseInt(current_position ) < parseInt(search)){
						//first comparison
						calc_count++;
						
						//alert(current_position+" < "+search+" \ngo to the right...");
						$("#grid tbody tr:nth-child(-n+"+row_start+") td:nth-child(-n+"+(col_start+1)+")").css("background-color","gray");
						$("#grid tbody tr:eq("+row_start+") td:eq("+col_start+")").css("background-color","red");
						col_start++;
						//increase from position change
						calc_count++;
					}else if(parseInt(current_position) > parseInt(search)){
						//increase twice because 2 comparisons at this point
						calc_count++;
						calc_count++;
						//alert(current_position+" > "+search+" \ngo up one...");
						$("#grid tbody tr:eq("+row_start+") td:eq("+(col_start)+")").nextUntil().css("background-color","gray");
						$("#grid tbody tr:eq("+row_start+") td:eq("+col_start+")").css("background-color","red");
						
						//increase because of position change
						calc_count++;
						row_start--;
					}else{
						//comparison matches
						calc_count++;
						calc_count++;
						found=true;
						//alert("match");
						$("#grid tbody tr:eq("+row_start+") td:eq("+col_start+")").css("background-color","green");
					}
					calc_count = calc_count+2;
					if (col_start>col_max||row_start<0){
						iteration++;
						break;
					}
					$("#mo").text(calc_count);
					$("#iter").text(iteration);
				}
				$("#ans").text(found);
				return false;
			});
		});
	</script>
   
  </head>
  <body id="body">
    <div class="container">