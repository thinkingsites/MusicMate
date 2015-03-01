var Player = React.createClass({
	getInitialState : function(){
		return { 
				repeatState : 0,
				shuffleState : 0,
				playing : false,
				label : "Press play to start" 
		}
	},
	shuffleTypes : [
		"Shuffle - true random",
		"Shuffle - favor favorites",
		"Shuffle - favor unplayed"
	],
	repeatTypes :[
		"Repeat None",
		"Repeat One",
		"Repeat All"
	],
	getStateText : function(which){
		var index = this.state[which + 'State'];
		return this[which + 'Types'][index];
	},
	nextState : function(which){
		var index = this.state[which + 'State'];
		index += 1;
		if(index >= this[which + 'Types'].length)
			index = 0;
		this.state[which + 'State'] = index;
		this.setState(this.state);
	},				
	togglePlay : function(){
		this.state.playing = !this.state.playing;
		var audio = this.getAudioTag();	
		if(this.state.playing)
			audio.play();
			//this.state.label = audio.src;
		else {
			audio.pause();
		}
		this.setState(this.state);
	},
	getAudioTag : function(){
		return this.getDOMNode().getElementsByTagName('audio')[0];
	},
	render : function(){
		return (
			<div>
				<div class="label">{this.state.label}</div>
				<button>Previous</button>
				<button onClick={this.togglePlay}>{this.state.playing ? 'Pause' : 'Play'}</button>
				<button>Next</button>
				<button onClick={_.partial(this.nextState,'shuffle')}>{this.getStateText('shuffle')}</button>
				<button onClick={_.partial(this.nextState,'repeat')}>{this.getStateText('repeat')}</button>
				<audio>
					<source src="music/grinderman.mp3" type="audio/mpeg"/>
				</audio>
			</div>
		);
	}
});	