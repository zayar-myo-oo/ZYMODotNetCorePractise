var myGuides = $.guides({
  guides: [{
    element: $('.TextBox'),
    html: 'This is a textbox that you want to save'
  }
  ]
});

// start the tour
myGuides.start();