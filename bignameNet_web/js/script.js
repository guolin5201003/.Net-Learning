// script.js
document.addEventListener('DOMContentLoaded', (event) => {
    const assetTrackingImg = document.getElementById('assetTrackingImg');
    const responseDisplay = document.getElementById('responseDisplay');

    assetTrackingImg.addEventListener('click', function () {
        alert('Asset Tracking Clicked!');

        // 调用函数来处理资产追踪点击事件
        handleAssetTrackingClick(responseDisplay);
    });

    function handleAssetTrackingClick(displayElement) {
        console.log('Asset Tracking function executed.');

        // 发送 AJAX 请求到服务端的 Web API
        const xhr = new XMLHttpRequest();
        const url = 'https://yourserver.com/api/asset-tracking'; // 替换为您的 Web API URL
        const method = 'GET'; // 假设您的 API 支持 GET 请求来获取数据

        xhr.open(method, url, true);
        xhr.setRequestHeader('Content-Type', 'application/json'); // 如果 API 需要这个头，即使它是 GET 请求

        // 定义请求完成时的回调函数
        xhr.onreadystatechange = function () {
            if (xhr.readyState === XMLHttpRequest.DONE) {
                if (xhr.status === 200) {
                    // 请求成功，处理响应数据
                    try {
                        const responseData = JSON.parse(xhr.responseText);
                        // 假设响应是一个 JSON 对象，并且您想显示其中的一个属性
                        displayElement.textContent = `Server response: ${responseData.someProperty}`; // 替换 someProperty 为实际的属性名
                    } catch (error) {
                        console.error('Error parsing JSON response:', error);
                        displayElement.textContent = 'Error parsing server response.';
                    }
                } else {
                    // 请求失败，处理错误
                    displayElement.textContent = `Error: ${xhr.statusText} (${xhr.status})`;
                }
            }
        };

        // 发送请求（GET 请求不需要数据参数）
        xhr.send();
    }
});