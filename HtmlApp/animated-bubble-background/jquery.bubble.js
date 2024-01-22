/*----------------------------- bubble -----------------------------*/
(function($){
	const 
	defaults = {
		messageNoSupport:'グラフを表示するには、canvasタグをサポートしたブラウザが必要です。', 
		namespace:'bubble_', 
		img:[], 
		imgSize:{
			min:30, 
			max:80 
		}, 
		imgs:false, 
		bubbles:false, 
		shadowColor:[
			'#F00', 
			'#0F0' 
		], 
		shadowBlur:1, 
		granularity:0.01, 
		bubbleFunc:false, 
		radiusFunc:false, 
		angleFunc:false, 
		velocityFunc:false, 
		animate:true 
	}, 
	selectorRule = {
		id:'#', 
		class:'.' 
	};
	$.fn.bubble = function(options){
		let 
		configs = {}, 
		el = this, 
		lenEl = el.length;
		if(lenEl === 0)
		return this;
		if(lenEl > 1){
			el.each(function(){
				$(this).bubble(options);
			});
			return this;
		}
		let 
		canvas, 
		canvasWidth, 
		canvasHeight, 
		bubblesConfigs = [], 
		imgsConfigs = [], 
		funcDestructor = () => {
			lenEl = 
			funcInit = 
			funcGetRandomInt = 
			funcGetRandomArray = 
			funcImgLoad = 
			funcPutCanvas = 
			funcEditConfigs = 
			funcPutCanvasAttribute = 
			funcPutBubblesConfigs = 
			funcGetRandomNumber = 
			funcDestructor = void 0;
		}, 
		funcInit = () => {
			configs = $.extend(
				{}, 
				defaults, 
				options 
			);
			funcImgLoad((eleImg) => {
				funcPutCanvas();
				funcEditConfigs();
				funcPutCanvasAttribute();
				funcPutBubblesConfigs(eleImg);
				funcShowBubbles();
				funcDestructor();
			});
		}, 
		funcGetRandomNumber = () => {
			return Math.random();
		}, 
		funcGetRandomInt = (
			min, 
			max 
		) => {
			return Math.floor(
				Math.random() * (
					max + 1 - min 
				) 
			) + min;
		}, 
		funcGetRandomArray = (array) => {
			return array[Math.floor(Math.random() * array.length)];
		}, 
		funcImgLoad = (callback) => {
			let 
			eleImg = [], 
			l = configs.img.length;
			if(l === 0)
			callback(eleImg);
			let 
			count = 0;
			for(var i = 0;i < l;++i){
				eleImg[i] = $('<img>');
				eleImg[i]
				.on(
					'load error', 
					() => {
						count++;
						if(l === count)
						callback(eleImg);
					} 
				);
				eleImg[i].attr(
					'src', 
					configs.img[i] 
				);
			}
		}, 
		funcPutCanvas = () => {
			el.append('\
				<canvas class="' + configs.namespace + 'canvas">\
					' + configs.messageNoSupport + '\
				</canvas>\
			');
			const 
			eleCanvas = $(selectorRule.class + configs.namespace + 'canvas', el);
			canvasWidth = el.width();
			canvasHeight = el.height();
			eleCanvas
			.attr({
				'width':canvasWidth, 
				'height':canvasHeight 
			});
		}, 
		funcEditConfigs = () => {
			if(configs.bubbles === false)
			configs.bubbles = Math.floor(
				configs.granularity * (
					canvasWidth + 
					canvasHeight 
				) 
			);
			if(configs.imgs === false)
			configs.imgs = Math.floor(
				configs.granularity * (
					canvasWidth + 
					canvasHeight 
				) 
			);
			if(configs.bubbleFunc === false)
			configs.bubbleFunc = () => {
				return 'hsla(0, 0%, 100%, ' + 0.1 * funcGetRandomNumber() + ')';
			};
			if(configs.radiusFunc === false)
			configs.radiusFunc = () => {
				return funcGetRandomNumber() * canvasWidth / 30;
			};
			if(configs.angleFunc === false)
			configs.angleFunc = () => {
				return funcGetRandomNumber() * Math.PI * 2;
			};
			if(configs.velocityFunc === false)
			configs.velocityFunc = () => {
				return funcGetRandomNumber();
			};
		}, 
		funcPutCanvasAttribute = () => {
			const 
			eleCanvas = $(selectorRule.class + configs.namespace + 'canvas', el);
			canvas = eleCanvas.get(0).getContext('2d');
			canvas.shadowBlur = configs.shadowBlur;
		}, 
		funcPutBubblesConfigs = (eleImg) => {
			for(var i = 0, l = configs.bubbles;i < l;++i)
			bubblesConfigs.push({
				bubbleFunc:(configs.bubbleFunc).call(), 
				shadowColor:funcGetRandomArray(configs.shadowColor), 
				x:funcGetRandomNumber() * canvasWidth, 
				y:funcGetRandomNumber() * canvasHeight, 
				radius:(configs.radiusFunc).call(), 
				angle:(configs.angleFunc).call(), 
				velocity:(configs.velocityFunc).call() 
			});
			if(eleImg.length){
				for(var i = 0, l = configs.imgs;i < l;++i)
				imgsConfigs.push({
					eleImg:funcGetRandomArray(eleImg), 
					x:funcGetRandomNumber() * canvasWidth, 
					y:funcGetRandomNumber() * canvasHeight, 
					size:funcGetRandomInt(
						configs.imgSize.min, 
						configs.imgSize.max 
					), 
					radius:(configs.radiusFunc).call(), 
					angle:(configs.angleFunc).call(), 
					velocity:(configs.velocityFunc).call() 
				});
			}
		}, 
		funcShowBubbles = (timestamp) => {
			canvas.clearRect(
				0, 
				0, 
				canvasWidth, 
				canvasHeight 
			), 
			bubblesConfigs.forEach((object) => {
				canvas.beginPath(), 
				canvas.arc(
					object.x, 
					object.y, 
					object.radius, 
					0, 
					2 * Math.PI 
				), 
				canvas.shadowColor = object.shadowColor, 
				canvas.fillStyle = object.bubbleFunc, 
				canvas.fill(), 
				object.x += Math.cos(object.angle) * object.velocity, 
				object.y += Math.sin(object.angle) * object.velocity, 
				object.x - object.radius > canvasWidth && (object.x = -object.radius), 
				object.x + object.radius < 0 && (object.x = canvasWidth + object.radius), 
				object.y - object.radius > canvasHeight && (object.y = -object.radius), 
				object.y + object.radius < 0 && (object.y = canvasHeight + object.radius);
			});
			imgsConfigs.forEach((object) => {
				size = configs.imgMaxSize
				canvas.drawImage($(object.eleImg).get(0), object.x, object.y, object.size, object.size), 
				object.x += Math.cos(object.angle) * object.velocity, 
				object.y += Math.sin(object.angle) * object.velocity, 
				object.x - object.radius > canvasWidth && (object.x = -object.radius), 
				object.x + object.radius < 0 && (object.x = canvasWidth + object.radius), 
				object.y - object.radius > canvasHeight && (object.y = -object.radius), 
				object.y + object.radius < 0 && (object.y = canvasHeight + object.radius);
			});
			if(configs.animate)
			window.requestAnimationFrame((timestamp) => funcShowBubbles(timestamp));
		};
		funcInit();
		return this;
	};
})(jQuery);
/*----------------------------- /bubble -----------------------------*/