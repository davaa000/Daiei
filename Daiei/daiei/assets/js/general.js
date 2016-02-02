//Elements
var themeElements = {
	menu: '.element-menu',
	select: '.element-select',
	slider: '.element-slider',
	submit: '.element-submit',
	rating: '.element-rating',
	colorbox: '.element-colorbox',
	upload: '.element-upload',
	form: '.element-form',
	file: '.element-file',
	trigger: '.element-trigger',
	facebook: '.element-facebook',
	chosen: '.element-chosen',
	copy: '.element-copy',
	options: '.element-options',
	remove: '.element-remove',
	clone: '.element-clone',
}

//DOM Loaded
jQuery(document).ready(function($) {

	//Menu
	$(themeElements.menu).find('li').hoverIntent(
		function() {
			var menuItem=$(this);
			menuItem.parent('ul').css('overflow','visible');
			menuItem.children('ul').slideToggle(200, function() {
				menuItem.addClass('hover');
			});
		},
		function() {
			var menuItem=$(this);
			menuItem.children('ul').slideToggle(200, function() {
				menuItem.removeClass('hover');
			});
		}
	);

	//Select
	function initSelect() {
		$(themeElements.select).each(function() {
			var element=$(this);
			
			element.find('select:first').fadeTo(0, 0);
			if(element.hasClass('redirect')) {
				element.find('option').each(function() {
					if(window.location.href==$(this).val()) {
						$(this).attr('selected','selected');					
					}
				});
			}
			
			element.find('span').text($.trim(element.find('option:first').text()));
			if(element.find('option:selected').length) {
				element.find('span').text($.trim(element.find('option:selected').text()));
			}
			
			element.on('click, change', function() {
				element.find('span').text($.trim($(this).find('option:selected').text()));			
				if(element.hasClass('redirect')) {
					window.location.href=$(this).find('option:selected').val();
				}
			});
		});
	}
	
	initSelect();
	
	//Trigger
	$(themeElements.trigger).each(function() {
		var id=$(this).attr('id').replace(/_/g, '-'),
			current=$(this).find('option:first').val();
			
		if($(this).find('option:selected').length) {
			current=$(this).find('option:selected').val();
		}
		
		$(this).find('option').each(function() {
			$('.trigger-'+id+'-'+$(this).val()).hide();
		});
		
		$('.trigger-'+id+'-'+current).show();
		$(this).change(function() {
			$(this).find('option').each(function() {
				$('.trigger-'+id+'-'+$(this).val()).hide();
			});
			
			$('.trigger-'+id+'-'+$(this).val()).show();
		});
	});
	
	//Chosen
	if(jQuery().chosen) {
		$(themeElements.chosen).chosen();
	}
	
	//Options
	$(themeElements.options).each(function() {
		var element=$(this),
			id=$(this).attr('id').replace(/_/g, '-');
		
		element.find('a').click(function() {
			var name=$(this).attr('href').replace('#', '-'),
				option=$('.option-'+id+name);
			
			if($(this).is(themeElements.remove)) {
				$(this).parent().remove();
				option.remove();
			} else {
				if($(this).is(themeElements.clone) && option.is(':visible')) {
					var clone=option.clone().removeClass('option-'+id+name).addClass('option-'+id+'-temp').insertAfter(option);
					
					clone.find('input').val('');
					clone.find('select').prop('selectedIndex', 0);
					initSelect();
				} else {
					element.find('a').each(function() {
						var name=$(this).attr('href').replace('#', '-');
						$('.option-'+id+name).hide();
					});
					
					option.show();
					$('.option-'+id+'-temp').remove();
				}
			}
			
			return false;
		});
	});
	
	//Colorbox
	$(themeElements.colorbox).each(function() {
		var inline=false;
		
		if($(this).attr('href').charAt(0)=='#') {
			inline=true;
		}
	
		$(this).colorbox({
			rel: $(this).data('rel'),
			inline: inline,
			current: '',
            loop: false,
			width: '320px',
		});
	});
	
	//Slider
	$(themeElements.slider).each(function() {
		var sliderOptions= {
			effect: $(this).data('effect'),
			pause: $(this).data('pause'),
			speed: $(this).data('speed'),
		};
		
		$(this).themexSlider(sliderOptions);
	});
	
	//Submit
	$(themeElements.submit).click(function() {
		if(!$(this).hasClass('disabled')) {
			var form=$($(this).attr('href'));
			
			if(typeof $(this).data('value')!=='undefined') {
				$($(this).attr('href')).val($(this).data('value'));
			}
		
			if(!form.length || !form.is('form')) {
				form=$(this).parent();
				while(!form.is('form')) {
					form=form.parent();
				}
			}
				
			form.submit();
		}
				
		return false;
	});
	
	//Facebook
	$(themeElements.facebook).click(function() {
		var redirect=$(this).attr('href');
		
		if(typeof(FB)!='undefined') {
			FB.login(function(response) {
				if (response.authResponse) {
					window.location.href=redirect;
				}
			}, {
				scope: 'email',
			});
		}
		
		return false;
	});
	
	//Rating
	$(themeElements.rating).each(function() {
		var title=$(this).parent().attr('title');
		
		$(this).raty({
			score: $(this).data('score'),
			readOnly: true,
			halfShow: false,
			hints: [title, title, title, title, title],
			noRatedMsg: '',
		});
	});
	
	//Copy
	$(themeElements.copy).click(function() {
		this.select();
	});
	
	//Uploader
	$(themeElements.upload).change(function() {
		var form=$(this).parent();
		
		while(!form.is('form')) {
			form=form.parent();
		}
		
		form.submit();
	});
	
	//File
	$(themeElements.file).change(function() {
		var name=$(this).val().replace(/^.*[\\\/]/, '');
		
		$(this).parent().children('span').text(name);
	});
	
	//Form
	$(themeElements.form).each(function() {
		var form=$(this);
		
		form.submit(function() {
			var message=form.find('.message'),
				loader=form.find('.loader'),
				toggle=form.find('.toggle'),
				button=form.find(themeElements.submit);
				
			var data={
				action: form.find('.action').val(),
				nonce: form.find('.nonce').val(),
				data: form.serialize(),
			}
			
			if(!form.hasClass('option')) {
				if(!message.length) {
					message=$('<div class="message" />').prependTo(form);
				}
				
				if(!loader.length) {
					loader=$('<div class="loader" />').appendTo(form);
				}
			}
			
			loader.show();
			button.addClass('disabled');
			
			message.slideUp(300, function() {
				$(themeElements.colorbox).colorbox.resize();
			});
			
			if(button.data('title')) {
				var title=button.data('title');
				
				if(button.attr('title')) {
					button.data('title', button.attr('title'));
					button.attr('title', title);
				} else {
					button.data('title', button.text());
					button.text(title);
				}				
				
				button.toggleClass('active');
			}
			
			toggle.each(function() {
				var value=toggle.val();
				
				toggle.val(toggle.data('value'));
				toggle.data('value', value);
			});
			
			jQuery.post(form.attr('action'), data, function(response) {
				loader.hide();
				button.removeClass('disabled');
				
				if(response!='' &&  response!='0' && response!='-1') {
					if(jQuery('.redirect', response).length) {
						if(jQuery('.redirect', response).attr('href')) {
							window.location.href=jQuery('.redirect',response).attr('href');
						} else {
							window.location.reload();
						}
					} else {
						message.html(response).slideDown(300, function() {
							$(themeElements.colorbox).colorbox.resize();
						});					
					}					
				}
			});
			
			return false;
		});
	});
	
	//DOM Elements
	$('p:empty').remove();
	$('h1,h2,h3,h4,h5,h6,blockquote').prev('br').remove();
	
	$('ul, ol').each(function() {
		if($(this).css('list-style-type')!='none') {
			$(this).css('padding-left', '1em');
			$(this).css('text-indent', '-1em');
		}
	});
	$('#colorbox, #cboxOverlay').appendTo('.main-form');
});