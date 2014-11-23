function createImagesPreviewer(selector, items) {
    var container = document.querySelector(selector);
    
    var bigImageContainer = document.createElement('div');
    bigImageContainer.style.textAlign = 'center';
    bigImageContainer.style.display = 'inline-block';
    bigImageContainer.style.width = '30%';
    bigImageContainer.style.padding = '15px';

    var bigImageTitle = document.createElement('h1');
    bigImageTitle.innerHTML = items[0].title;
    bigImageTitle.style.marginTop = '0px';

    var bigImageImageContainer = document.createElement('div');

    var bigImageImage = document.createElement('img');
    bigImageImage.src = items[0].url;
    bigImageImage.style.width = '100%'
    bigImageImage.style.height = '100%'
    bigImageImage.style.borderRadius = '15px';

    bigImageImageContainer.appendChild(bigImageImage);
    bigImageContainer.appendChild(bigImageTitle);
    bigImageContainer.appendChild(bigImageImageContainer);
    container.appendChild(bigImageContainer);

    var imageListContainer = document.createElement('div');
    imageListContainer.style.textAlign = 'center';
    imageListContainer.style.display = 'inline-block';
    imageListContainer.style.width = '140px';
    imageListContainer.style.height = '360px';
    imageListContainer.style.overflow = 'auto';

    var filterLabel = document.createElement('label');
    filterLabel.innerHTML = 'Filter';
    filterLabel.htmlFor = 'filterForImages';

    var inputFilter = document.createElement('input');
    inputFilter.type = 'text';
    inputFilter.id = 'filterForImages';
    inputFilter.style.width = '95%';

    var docFragment = document.createDocumentFragment();

    for (var i = 0; i < items.length; i++) {
        var thumbContainer = document.createElement('div');

        var thumbTitle = document.createElement('strong');
        thumbTitle.innerHTML = items[i].title;

        var thumbImage = document.createElement('img');
        thumbImage.src = items[i].url;
        thumbImage.style.width = '95%';
        thumbImage.style.height = '95%';
        thumbImage.style.borderRadius = '5px';

        thumbContainer.appendChild(thumbTitle);
        thumbContainer.appendChild(thumbImage);

        thumbContainer.addEventListener('mouseover', function () {
            this.style.backgroundColor = 'gray';
        })

        thumbContainer.addEventListener('mouseout', function () {
            this.style.backgroundColor = 'white';
        })

        thumbContainer.addEventListener('click', function () {
            bigImageTitle.innerHTML = this.firstChild.innerHTML;
            bigImageImage.src = this.lastChild.src;
        })

        docFragment.appendChild(thumbContainer);
    }

    inputFilter.addEventListener('keyup', function () {
        var thumbContainers = imageListContainer.querySelectorAll('div');

        if (this.value !== '') {
            for (var i = 0; i < thumbContainers.length; i++) {
                if (thumbContainers[i].innerText.toLowerCase().indexOf(this.value) == -1) {
                    thumbContainers[i].style.display = 'none';
                } else {
                    thumbContainers[i].style.display = '';
                }
            }
        } else {
            for (var i = 0; i < thumbContainers.length; i++) {
                    thumbContainers[i].style.display = '';
            }
        }
    })

    imageListContainer.appendChild(filterLabel);
    imageListContainer.appendChild(inputFilter);
    imageListContainer.appendChild(docFragment);
    container.appendChild(imageListContainer);
}