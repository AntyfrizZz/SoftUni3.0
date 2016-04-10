jQuery(document).ready(function($) {
        
	
	$( '#story-form' ).submit(function( e ) { e.preventDefault(); });
	
	$('#submitlink').on( 'click', function( e ) {
	    
	    e.preventDefault();
		var subnamevalue  = $( '#name' ).val();
		var emailvalue    = $( '#email' ).val();
		var usercaptvalue = $( '#captchavalue' ).val();
		var msgvalue      = $( '#message' ).val();
		
		var postchecks = userSendMailStatus( subnamevalue, emailvalue, msgvalue, usercaptvalue);
	});
	
    function checkValidEmailAddress(emailAddress) {
        var pattern = new RegExp(/^(("[\w-+\s]+")|([\w-+]+(?:\.[\w-+]+)*)|("[\w-+\s]+")([\w-+]+(?:\.[\w-+]+)*))(@((?:[\w-+]+\.)*\w[\w-+]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][\d]\.|1[\d]{2}\.|[\d]{1,2}\.))((25[0-5]|2[0-4][\d]|1[\d]{2}|[\d]{1,2})\.){2}(25[0-5]|2[0-4][\d]|1[\d]{2}|[\d]{1,2})\]?$)/i);
        
        return pattern.test(emailAddress);
    };

    var mailsendstatus;
    function userSendMailStatus( uname, uemail, umsg, ucaptcha ) {
        
    	// checking for some valid user name
    	if( !uname ) {
    		$( '#namelabel' ).closest('.fieldDiv').children( '.err' ).fadeIn( 'slow' );
    	}
    	else if( uname.length > 3 ) {
    		$( '#namelabel' ).closest('.fieldDiv').children( '.err' ).fadeOut( 'slow' );		
    	}
    	
    	// checking for valid email
    	if( !checkValidEmailAddress( uemail ) ) {
    		$( '#emailabel' ).closest('.fieldDiv').children( '.err' ).fadeIn( 'slow' );
    	}
    	else if( checkValidEmailAddress( uemail ) ) {
    		$( '#emailabel' ).closest('.fieldDiv').children( '.err' ).fadeOut( 'slow' );	
    	}
    	
    	// checking for valid message
    	if( !umsg ) {
    		$( '#msglabel' ).closest('.fieldDiv').children( '.err' ).fadeIn( 'slow' );
    	}
    	else if(umsg.length > 5) {
    		$( '#msglabel' ).closest('.fieldDiv').children( '.err' ).fadeOut( 'slow' );
    	}
    	
    	// ajax check for captcha code
    	$.ajax(
    	    {
    			type: 'POST',
    			url: '../perform_check.php',
    			data: $("#story-form").serialize(),
    			success: function( data ) {
    				if( data == 'false' ) {
    					mailsendstatus = false;
    					$( '#captchalabel' ).closest('.fieldDiv').children( '.err' ).fadeIn( 'slow' );
    				}
    				else if( data == 'true' ){
    					$( '#captchalabel' ).closest('.fieldDiv').children( '.err' ).fadeOut( 'slow' );
    					
    					if( uname.length > 3 && umsg.length > 5 && checkValidEmailAddress( uemail ) ) {
    						mailsendstatus = true;
    						$( '#btnwrapper' ).html( '<img src="img/load.gif" alt="loading...">' );
    
    						$.ajax(
    							{
    								type: 'POST',
    								url: '../sendmail.php',
    								data: $( '#story-form' ).serialize(),
    								success: function( data ) {
    									if(data == 'yes' ) {
    									$( '#contactwrapper' ).slideUp( 650, function() {
    										$( this ).before( '<header><h4><strong>Супер, твоята история е изпратена!</strong></h4></header>' );
                                        });
    									}
    								}
    							}
    						); // close sending email ajax call	
    					} // close if logic for mailsendstatus true
    				} // close check CAPTCHA return true
    			} // close ajax success callback function
    		} // close ajax bracket open
    	);
    	
    	return mailsendstatus;
    }
    
});
