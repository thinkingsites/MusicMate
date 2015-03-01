var MusicList = React.createClass({
	getInitialState : function(){
		return { 
				list :[]
		}
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