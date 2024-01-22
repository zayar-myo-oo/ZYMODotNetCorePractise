(function ($) {
  $(document).ready(function () {
    const
      eleBody = $('body'),
      config = {
        img: [
          './animated-bubble-background/img/pink.png',
          './animated-bubble-background/img/yellow.png',
          './animated-bubble-background/img/green.png'
        ],
        shadowColor: [
          '#8bcecb',
          '#f2a2b9',
          '#f4b6d1',
          '#ca98c3',
          '#fff231',
          '#4ab7d0'
        ],
        bubbleFunc: () => {
          return 'hsla(0, 0%, 100%, 0.5)';
        }
      };
    eleBody.bubble(config);
  });
})(jQuery);


// $('body').bubble({
//   imgs: false,
//   bubbles: false,
// })

// $('body').bubble({
//   background: {
//     0: '#000',
//     1: '#FFF'
//   },
// })

// $('body').bubble({
//   namespace: 'bubble_',
//   animate: true, // enable animation
//   imgSize: {
//     min: 30,
//     max: 80
//   },
//   shadowBlur: 1,
//   granularity: 0.01,
//   globalCompositeOperationBackground: 'source-over',
//   globalCompositeOperationObject: 'source-over',
//   bubbleFunc: false,
//   radiusFunc: false,
//   angleFunc: false,
//   velocityFunc: false,
// };)