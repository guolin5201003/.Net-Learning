// script.js
document.addEventListener('DOMContentLoaded', (event) => {
    const assetTrackingImg = document.getElementById('assetTrackingImg');
    const responseDisplay = document.getElementById('responseDisplay');

    assetTrackingImg.addEventListener('click', function () {
        alert('Asset Tracking Clicked!');

        // ���ú����������ʲ�׷�ٵ���¼�
        handleAssetTrackingClick(responseDisplay);
    });

    function handleAssetTrackingClick(displayElement) {
        console.log('Asset Tracking function executed.');

        // ���� AJAX ���󵽷���˵� Web API
        const xhr = new XMLHttpRequest();
        const url = 'https://yourserver.com/api/asset-tracking'; // �滻Ϊ���� Web API URL
        const method = 'GET'; // �������� API ֧�� GET ��������ȡ����

        xhr.open(method, url, true);
        xhr.setRequestHeader('Content-Type', 'application/json'); // ��� API ��Ҫ���ͷ����ʹ���� GET ����

        // �����������ʱ�Ļص�����
        xhr.onreadystatechange = function () {
            if (xhr.readyState === XMLHttpRequest.DONE) {
                if (xhr.status === 200) {
                    // ����ɹ���������Ӧ����
                    try {
                        const responseData = JSON.parse(xhr.responseText);
                        // ������Ӧ��һ�� JSON ���󣬲���������ʾ���е�һ������
                        displayElement.textContent = `Server response: ${responseData.someProperty}`; // �滻 someProperty Ϊʵ�ʵ�������
                    } catch (error) {
                        console.error('Error parsing JSON response:', error);
                        displayElement.textContent = 'Error parsing server response.';
                    }
                } else {
                    // ����ʧ�ܣ��������
                    displayElement.textContent = `Error: ${xhr.statusText} (${xhr.status})`;
                }
            }
        };

        // ��������GET ������Ҫ���ݲ�����
        xhr.send();
    }
});