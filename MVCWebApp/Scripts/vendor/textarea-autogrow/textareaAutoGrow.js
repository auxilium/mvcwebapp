/**
 * jQuery Textarea AutoGrow
 *
 * Automatically grows <textarea> elements (vertically) to accommodate
 * its content. Has a minimum and maximum height and can trigger a
 * callback when the size changes.
 *
 * $('textarea').autoGrow({
 *		minHeight: 1,    // Min height (px), defaults to 1
 *		maxHeight: 1000, // Max height (px), defaults to 1000
 *		callback:  func  // Callback function, defaults to null
 * });
 *
 * Dual licensed under the MIT and GPL licenses:
 *
 *    http://www.opensource.org/licenses/mit-license.php
 *    http://www.gnu.org/licenses/gpl.html
 *
 * @author     David King
 * @copyright  Copyright (c) 2015 +
 * @url        oodavid.com
 */

(function($) {
	$(document).ready(function() {
		// Defaults
		var defaultOpts = {
			minHeight: 1,
			maxHeight: 1000,
			callback:  null
		};
		// This clipping element hides our clone elements
		var $clip = $('<div />').css({ height: '1px', overflow: 'hidden', visibility: 'hidden' });
		$('body').append($clip);
		// The callback logic
		function autoSize(e, $this, $clone, opts) {
			$clone.css('width', $this.css('width')); // Update the clone width, it may have changed
			$clone.html(escapeHTML($this.val())+'<br />'); // Copy the textarea contents into the clone element - the browser calculates the height
			var oldHeight = parseInt($this.css('height'), 10);  // Store the current (old) height
			var newHeight = parseInt($clone.css('height'), 10); // Grab the recalculated (new) height
			newHeight = Math.max(opts.minHeight, Math.min(newHeight, opts.maxHeight)); // Restrict within min / max
			// If there's a change in height, or the event was triggered manually, update and fire the callback
			if(oldHeight != newHeight || !e || e.originalEvent === undefined){
				$this.css('height', newHeight);
				if(opts.callback){
					opts.callback.call($this, e, newHeight, oldHeight);
				}
			}
		}
		// Exposed method
		$.fn.autoGrow = function(opts) {
			var $this = $(this),
			opts = $.extend({}, defaultOpts, (opts||{}));
			// Create a clone element with the same dimensions, font, padding etc.
			var $clone = $('<div />').css({
				font:                 $this.css('font'),
				padding:              $this.css('padding'),
				border:               $this.css('border'),
				'line-height':        $this.css('line-height'),
				'box-sizing':         $this.css('box-sizing'),            
				'-moz-box-sizing':    $this.css('-moz-box-sizing'),             
				'-ms-box-sizing':     $this.css('-ms-box-sizing'),             
				'-webkit-box-sizing': $this.css('-webkit-box-sizing')             
			});
			$clip.append($clone);
			// Add the events, pre-emptively resize
			$this.change ( function(e) { autoSize(e, $this, $clone, opts); } ) 
				 .keydown( function(e) { autoSize(e, $this, $clone, opts); } ) 
				 .keyup  ( function(e) { autoSize(e, $this, $clone, opts); } )
				 .focus  ( function(e) { autoSize(e, $this, $clone, opts); } );
			autoSize(null, $this, $clone, opts);
		};
		// HTML Character Replacement
		var escapeMap = {
			'&':  '&amp;',
			'<':  '&lt;',
			'>':  '&gt;',
			'"':  '&#34;',
			"'":  '&#39;',
			'\n': '<br />'
		};
		function escapeCB(m){
			return escapeMap[m];
		}
		function escapeHTML(s){
			return s.replace(/[&<>'"\n]/g, escapeCB);
		}
	});
})(jQuery);
